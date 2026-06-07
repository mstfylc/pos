//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/assignment_table_type.dart';
import 'package:mansis_pos_api_client/model/assignment_record.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'assignment.g.dart';

abstract class Assignment implements Built<Assignment, AssignmentBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'assignmentTableType')
    AssignmentTableType get assignmentTableType;
    // enum assignmentTableTypeEnum {  Pos,  Branch,  Store,  };

    @BuiltValueField(wireName: r'records')
    BuiltList<AssignmentRecord> get records;

    Assignment._();

    static void _initializeBuilder(AssignmentBuilder b) => b;

    factory Assignment([void updates(AssignmentBuilder b)]) = _$Assignment;

    @BuiltValueSerializer(custom: true)
    static Serializer<Assignment> get serializer => _$AssignmentSerializer();
}

class _$AssignmentSerializer implements StructuredSerializer<Assignment> {

    @override
    final Iterable<Type> types = const [Assignment, _$Assignment];
    @override
    final String wireName = r'Assignment';

    @override
    Iterable<Object> serialize(Serializers serializers, Assignment object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'assignmentTableType')
            ..add(serializers.serialize(object.assignmentTableType,
                specifiedType: const FullType(AssignmentTableType)));
        result
            ..add(r'records')
            ..add(serializers.serialize(object.records,
                specifiedType: const FullType(BuiltList, [FullType(AssignmentRecord)])));
        return result;
    }

    @override
    Assignment deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = AssignmentBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'assignmentTableType':
                    result.assignmentTableType = serializers.deserialize(value,
                        specifiedType: const FullType(AssignmentTableType)) as AssignmentTableType;
                    break;
                case r'records':
                    result.records.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(AssignmentRecord)])) as BuiltList<AssignmentRecord>);
                    break;
            }
        }
        return result.build();
    }
}

