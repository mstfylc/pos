//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_record.g.dart';

abstract class AssignmentRecord implements Built<AssignmentRecord, AssignmentRecordBuilder> {

    @BuiltValueField(wireName: r'recordId')
    String get recordId;

    @BuiltValueField(wireName: r'recordName')
    String get recordName;

    AssignmentRecord._();

    static void _initializeBuilder(AssignmentRecordBuilder b) => b;

    factory AssignmentRecord([void updates(AssignmentRecordBuilder b)]) = _$AssignmentRecord;

    @BuiltValueSerializer(custom: true)
    static Serializer<AssignmentRecord> get serializer => _$AssignmentRecordSerializer();
}

class _$AssignmentRecordSerializer implements StructuredSerializer<AssignmentRecord> {

    @override
    final Iterable<Type> types = const [AssignmentRecord, _$AssignmentRecord];
    @override
    final String wireName = r'AssignmentRecord';

    @override
    Iterable<Object> serialize(Serializers serializers, AssignmentRecord object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'recordId')
            ..add(serializers.serialize(object.recordId,
                specifiedType: const FullType(String)));
        result
            ..add(r'recordName')
            ..add(serializers.serialize(object.recordName,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    AssignmentRecord deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentRecordBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'recordId':
                    result.recordId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'recordName':
                    result.recordName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

