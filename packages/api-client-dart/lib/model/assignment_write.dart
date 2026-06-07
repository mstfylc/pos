//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/assignment_table_type.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment_write.g.dart';

abstract class AssignmentWrite implements Built<AssignmentWrite, AssignmentWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'assignmentTableType')
    AssignmentTableType get assignmentTableType;
    // enum assignmentTableTypeEnum {  Pos,  Branch,  Store,  };

    @BuiltValueField(wireName: r'recordIds')
    BuiltList<String> get recordIds;

    AssignmentWrite._();

    static void _initializeBuilder(AssignmentWriteBuilder b) => b;

    factory AssignmentWrite([void updates(AssignmentWriteBuilder b)]) = _$AssignmentWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<AssignmentWrite> get serializer => _$AssignmentWriteSerializer();
}

class _$AssignmentWriteSerializer implements StructuredSerializer<AssignmentWrite> {

    @override
    final Iterable<Type> types = const [AssignmentWrite, _$AssignmentWrite];
    @override
    final String wireName = r'AssignmentWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, AssignmentWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'assignmentTableType')
            ..add(serializers.serialize(object.assignmentTableType,
                specifiedType: const FullType(AssignmentTableType)));
        result
            ..add(r'recordIds')
            ..add(serializers.serialize(object.recordIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    AssignmentWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'assignmentTableType':
                    result.assignmentTableType = serializers.deserialize(value,
                        specifiedType: const FullType(AssignmentTableType)) as AssignmentTableType;
                    break;
                case r'recordIds':
                    result.recordIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

